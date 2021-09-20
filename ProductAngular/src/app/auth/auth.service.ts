import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { throwError, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  readonly url = `${environment.apiUrl}/auth`

  constructor(private http: HttpClient) { }

  watchUser() {

  }

  getUser() {

  }

  login(displayName: string, password: string) {
    return this.http.post(`${this.url}/login`, { displayName, password })
      .pipe(catchError(error => this.onError("login", error)))
  }

  logout() {
    return this.http.post(`${this.url}/logout`, {})
      .pipe(catchError(error => this.onError("logout", error)))
  }

  onError<T>(operation: string, error: any, fallback?: T) {
    console.error(operation, error)
    if (fallback == undefined) throwError(error)
    return of(fallback);
  }
}
