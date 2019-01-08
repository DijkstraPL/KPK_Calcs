import { Component, Inject, OnInit, Pipe, PipeTransform } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { forEach } from '@angular/router/src/utils/collection';
import { error } from '@angular/compiler/src/util';
import { KeyValue } from '@angular/common';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit {

  public selectedScript: Script;
  public scripts: Script[];
  public parameters: Parameter[];
  public parameterOptions = ParameterOptions;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

  }

  ngOnInit(): void {
    this.getScripts();
  }

  getScripts() {
    this.http.get<Script[]>(this.baseUrl + 'api/SampleData/Scripts')
      .subscribe(result => { this.scripts = result; },
        error => console.error(error));
  }

  calculate() {
    let parameters: string = "";
    this.selectedScript.parameters.filter(parameter => (parameter.context & ParameterOptions.Editable) != 0)
      .forEach(parameter => {
        parameters += "[";
        parameters += parameter.name;
        parameters += "]=";
        parameters += parameter.value;
        parameters += "|";
      });
    parameters = parameters.substr(0, parameters.length - 1);

    this.http.get<Parameter[]>(this.baseUrl + 'api/SampleData/Calculate/' + this.selectedScript.name + '/' + parameters)
      .subscribe(result => { this.selectedScript.parameters = result; },
        error => console.error(error));
  }
}


interface Script {
  name: string;
  description: string;
  parameters: Parameter[];
  tags: string[];
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
