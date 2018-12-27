import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public parameters: Parameter[];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.http.get<Parameter[]>(this.baseUrl + 'api/SampleData/Parameters')
      .subscribe(result => { this.parameters = result; }, error => console.error(error));
  }
  
  public calculate() {
    this.http.post( this.baseUrl + 'api/SampleData/Calculate', "Test");
  }
}

interface Parameter {
  name: string;
  description: string;
  value: object;
  unit: string;
}
