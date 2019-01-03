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
    this.getParameters();
  }

  getScripts() {
    this.http.get<Script[]>(this.baseUrl + 'api/SampleData/Scripts')
      .subscribe(result => { this.scripts = result; },
        error => console.error(error));
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

@Pipe({ name: 'html' })
export class HtmlPipe implements PipeTransform {
  transform(html: string): string {
    let finalHtml = "";
    let inSubScript = false;
    let inSupScript = false;
    for (let i = 0; i < html.length; i++) {

      if (html[i] == "_" && !inSubScript) {
        finalHtml += "<sub>";
        inSubScript = true;
      }
      else if (html[i] == "_" && inSubScript) {
        finalHtml += "</sub>";
        inSubScript = false;
      }
      else if (html[i] == "^" && !inSupScript) {
        finalHtml += "<sup>";
        inSupScript = true;
      }
      else if (html[i] == "^" && inSupScript) {
        finalHtml += "</sup>";
        inSupScript = false;
      }
      else
        finalHtml += html[i];
    }
    return finalHtml;
  }
}

interface Script {
  name: string;
  description: string;
  parameters: KeyValue<number, Parameter>[];
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
