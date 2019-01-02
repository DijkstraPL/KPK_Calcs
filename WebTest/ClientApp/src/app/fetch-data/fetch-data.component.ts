import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { forEach } from '@angular/router/src/utils/collection';
import { error } from '@angular/compiler/src/util';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit {

  public parameters: Parameter[];
  public parameterOptions = ParameterOptions;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

  }

  ngOnInit(): void {
    this.getParameters();
  }

  getParameters() {
    this.http.get<Parameter[]>(this.baseUrl + 'api/SampleData/Parameters')
      .subscribe(result => { this.parameters = result; },
        error => console.error(error));
  }

  calculate() {
    let parameters: string = "";
    this.parameters.filter(parameter => (parameter.context & ParameterOptions.Editable) != 0)
      .forEach(parameter => {
      parameters += "[";
      parameters += parameter.name;
      parameters += "]=";
      parameters += parameter.value;
      parameters += "|";
    });

    parameters = parameters.substr(0, parameters.length - 1);

    this.http.get<Parameter[]>(this.baseUrl + 'api/SampleData/Calculate/' + parameters)
      .subscribe(result => { this.parameters = result; },
      error => console.error(error));
  }
}

interface Parameter {
  name: string;
  value: object;
  description: string;
  valueOptions: ValueOption[];
  unit: string;
  context: ParameterOptions;
}

interface ValueOption {
  description: string;
  value: object;
}

enum ParameterOptions {
  None = 0,
  Visible = 1,
  Editable = 2,
  Calculation = 4,
  StaticData = 8,
}
