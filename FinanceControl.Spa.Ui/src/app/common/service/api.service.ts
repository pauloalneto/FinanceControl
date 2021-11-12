import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { finalize, map, catchError } from 'rxjs/operators';


@Injectable()
export class ApiService<T>{

  private _resource: string = '';
  private _apiDefault: string = '';

  constructor(private http: HttpClient) {

  }


  public get(): Observable<T>{
    return this.getBase(this.makeUrl());
  }

  public getDataCustom(filters?: any): Observable<T> {
    return this.getBaseCustom('GetDataCustom', filters)
  }

  private getBase(url: string, filters?: any): Observable<any> {
    return this.processResponse(this.http.get<any>(url, this.makeOptions(filters)));
  }

  private getBaseCustom(method: string, filters?: any): Observable<T> {
    if (filters == null)
      filters = {};

    filters.filterBehavior = method;
    return this.getBase(this.makeUrl(), filters);
  }

  public setResource(resource: string) : ApiService<T> {
    this._resource = resource;
    this._apiDefault = 'https://localhost:44378/weatherForecast';

    return this;
  }

  private makeOptions(filters?: any) {
    var options = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Authorization': "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiUGF1bG8hkjkjkjkgQWxtZWlkYSIsImVtYWlsIjoicGF1bG9fbWFjaGFkb19hQHlhaG9vLmNvbS5iciIsInJvbGUiOiJbXCJhZG1pbmlzdHJhdG9yXCJdIiwibmJmIjoxNjM0MDgyOTY0LCJleHAiOjE2MzQwOTAxNjQsImlhdCI6MTYzNDA4Mjk2NH0.WcADxRcl3ZJdrC5zgz5CPpHwQc80elT6onE54gvu45I" }),
    }

    //if (filters != null)
    //  Object.assign(options, { params: this.makeParams(filters)})

    return options;
  }

  private makeParams(filters: any) {
    let params = new HttpParams();
    if (filters != null) {
      for (const key in filters) {
        if (filters.hasOwnProperty(key))
          params = params.set(key, filters[key])
      }
      return params;
    }
    else {
      return params;
    }

  }

  private makeUrl() {
    /*   var url = `${this._apiDefault}/${this._resource}`*/
    var url = `${this._apiDefault}`
    return url;
  }

  private processResponse(response: Observable<Response>): Observable<any> {
    return response.pipe(
      map(res => { return res}),
      catchError(error => { return error }),
      finalize(() => { })
    );
  }
}
