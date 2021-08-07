import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
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

  private getBase(url: string): Observable<any> {
    return this.processResponse(this.http.get<any>(url, this.makeHeader()));
  }

  public setResource(resource: string) : ApiService<T> {
    this._resource = resource;
    this._apiDefault = 'https://localhost:44378/api';

    return this;
  }

  private makeHeader() {
    var httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }

    return httpOptions;
  }

  private makeUrl() {
    var url = `${this._apiDefault}/${this._resource}`
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
