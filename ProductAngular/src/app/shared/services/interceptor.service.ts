import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, switchMap } from 'rxjs/operators';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root',
})
export class InterceptorService implements HttpInterceptor {

  retry: number = 10

  constructor(
    private authService: AuthService,
  ) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return this.addAuthorizationToken(req, next);
  }

  addAuthorizationToken(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const options = {
      headers: request.headers
    }

    const token = this.authService.token()
    if (token.accessToken)
      options.headers = request.headers.set("Authorization", `Bearer ${token.accessToken}`);

    const authRequest = request.clone(options)

    return next.handle(authRequest)
      .pipe(catchError(error => {
        switch (error.status) {
          case 401:
            return this.authService.refresh().pipe(
              switchMap(value => {
                // retry 1 more time but with new token
                const newAuthOptions = {
                  headers: request.headers.set("Authorization", `Bearer ${value.accessToken}`)
                };
                const newAuthRequest = request.clone(newAuthOptions)
                return next.handle(newAuthRequest);
              })
            )
          default:
            return throwError(error)
        }
      }))
  }

}
