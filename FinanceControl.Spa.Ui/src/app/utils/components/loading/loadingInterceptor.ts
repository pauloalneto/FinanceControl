import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpResponse } from '@angular/common/http';
import { catchError, map } from 'rxjs/operators'
import { LoadingService } from './loading.service';
import { throwError } from 'rxjs';



@Injectable()
export class LoadingInterceptor implements HttpInterceptor {

  constructor(private loadingService: LoadingService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler) {
    this.loadingService.setLoading(true, request.url);

    return next.handle(request)
      .pipe(
        map((evt: HttpEvent<any>) => {
          if (evt instanceof HttpResponse) {
            this.loadingService.setLoading(false, request.url);
          }
          return evt;
        }),
        catchError((err, evt) => {
          this.loadingService.setLoading(false, request.url);
          return throwError(err.message);
        })
      )
  }
}
