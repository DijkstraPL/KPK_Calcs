import { Component, OnInit } from '@angular/core';
import { ParameterService } from '../../../services/parameter.service';
import { ActivatedRoute } from '@angular/router';
import { Parameter } from '../../../models/interfaces/parameter';
import { TestDataService } from '../../../services/test-data.service';
import { TestData } from '../../../models/interfaces/testData';
import { forkJoin } from 'rxjs';
import { TestParameter } from '../../../models/interfaces/testParameter';
import { ValueType } from '../../../models/enums/valueType';
import { ParameterOptions } from '../../../models/enums/parameterOptions';
import { Assertion } from '../../../models/interfaces/assertion';
import { CalculationService } from '../../../services/calculation.service';
import { AssertionImpl } from '../../../models/assertionImpl';
import { TestDataImpl } from '../../../models/testDataImpl';

@Component({
    selector: 'app-test-data-form',
    templateUrl: './test-data-form.component.html',
    styleUrls: ['./test-data-form.component.scss']
})

export class TestDataFormComponent implements OnInit {

    scriptId: number;
    parameters: Parameter[];
    testDatas: TestData[];
    valueTypes = ValueType;
    testDatasContainers: {
        testData: TestData,
        parametersPairs:
        {
            parameter: Parameter,
            testParameter: TestParameter
        }[],
        assertions: Assertion[]
        result: boolean;
        calculationResults: Parameter[];
    }[] = [];
    
    constructor(private parameterService: ParameterService,
        private testDataService: TestDataService,
        private calculationService: CalculationService,
        private route: ActivatedRoute) {
    }

    ngOnInit(): void {
        this.route.params.subscribe(params => {
            this.scriptId = +params['id'];
        });

        if (isNaN(this.scriptId))
            return;

        this.loadData();
    }

    private loadData() {
        let parameters$ = this.parameterService.getParameters(this.scriptId, "en");
        let testDatas$ = this.testDataService.getTestDatas(this.scriptId, "en");
        forkJoin(parameters$, testDatas$)
            .subscribe(responseList => {
                this.parameters = responseList[0];
                this.testDatas = responseList[1];
                this.setParametersTestData();
                this.testDatasContainers.forEach(tdp => this.test(tdp));
            });
    }

    addTestData() {
        this.testDataService.create(this.scriptId, new TestDataImpl())
            .subscribe(td => {
                this.testDatasContainers = [];
                this.loadData()
            });
    }

    removeTestData(testDataContainer) {
        this.testDataService.delete(testDataContainer.testData.id);
        this.testDatasContainers.filter(tdp => tdp.testData != testDataContainer.testData);
    }

    saveTestData(testDataContainer) {

    }

    getTestDatas(scriptId: number) {
        this.testDataService.getTestDatas(this.scriptId, "en")
            .subscribe(testDatas => {
                this.testDatas = testDatas;
            });
    }

    getParameters(id: number) {
        this.parameterService.getParameters(id, "en").subscribe(parameters => {
            this.parameters = parameters;
        }, error => console.error(error));
    }

    setParametersTestData() {
        this.testDatas.forEach(td => {
            let testDataParameterPairs = {
                testData: td,
                parametersPairs: [],
                assertions: td.assertions,
                result: false,
                calculationResults: []
            };
            this.testDatasContainers.push(testDataParameterPairs);

            this.parameters.forEach(p => {
                let testParameter = td.testParameters.find(tp => tp.parameterId == p.id);
                if (testParameter)
                    testDataParameterPairs.parametersPairs.push({ parameter: p, testParameter: testParameter });
                else
                    testDataParameterPairs.parametersPairs.push({parameter: p, testParameter: new TestParameterImpl(p)})


            });

            td.testParameters.forEach(tp => {
                let parameter = this.parameters.find(p => p.id == tp.parameterId);
                testDataParameterPairs.parametersPairs.push({ parameter: parameter, testParameter: tp });
            });
        });
    }

    isRequired(parameter: Parameter): boolean {
        return (parameter.context & ParameterOptions.optional) == 0;
    }

    fullTest(testDataContainer) {
        this.test(testDataContainer);
        this.calculate(testDataContainer);
    }

    test(testDataContainer) {
        testDataContainer.result = false;
        this.calculationService.test(this.scriptId, testDataContainer.testData)
            .subscribe(result => testDataContainer.result = result);
    }

    calculate(testDataContainer) {
        let parameters = testDataContainer.parametersPairs
            .map(pp => {
                pp.parameter.value = pp.testParameter.value;
                    return pp.parameter;
            });
        this.calculationService.calculate(this.scriptId, parameters)
            .subscribe(result =>
                testDataContainer.calculationResults =
                result.filter(r => (r.context & ParameterOptions.visible) != 0));
    }

    addAssertion(testDataParametersPairs) {
        testDataParametersPairs.assertions.push(new AssertionImpl());
    }

    removeAssertion(assertion: Assertion, testDataParametersPairs) {
        testDataParametersPairs.assertions = testDataParametersPairs.assertions
            .filter(a => a != assertion);
    }

    private getMatchingParameter(testParameter: TestParameter): Parameter {
        return this.parameters.find(p => p.id == testParameter.parameterId);
    }

    private getMatchingTestParameter(parameter: Parameter, parametersPairs): TestParameter {
        return parametersPairs.find(pp => pp.testParameter.parameterId == parameter.id);
    }
}
