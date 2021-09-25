import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { throwError, of, Subject, Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IAuthToken } from 'src/app/shared/models/auth';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  readonly url = `${environment.apiUrl}/auth`

  observer: Subject<IAuthToken> = new Subject<IAuthToken>()

  constructor(private http: HttpClient) { }

  onChanged() {
    return this.observer.asObservable();
  }

  user() {
    const accessToken = localStorage.getItem("access_token")
    const refreshToken = localStorage.getItem("refresh_token")

    if (refreshToken) return { accessToken, refreshToken }
    return undefined;
  }

  async login(displayName: string, password: string): Promise<IAuthToken> {
    return this.http.post<IAuthToken>(`${this.url}/login`, { displayName, password })
      .pipe(
        catchError(error => this.onError<IAuthToken>("login", error)),
        tap(token => {
          localStorage.setItem("access_token", token.accessToken!)
          localStorage.setItem("refresh_token", token.refreshToken!)
          this.observer.next(token)
        })
      )
      .toPromise()
  }

  logout() {
    this.observer.next(undefined)
    localStorage.removeItem("access_token")
    localStorage.removeItem("refresh_token")
  }

  onError<T>(operation: string, error: HttpErrorResponse, fallback?: T): Observable<T> {
    console.error(operation, error)
    if (fallback == undefined) return throwError(error)
    return of(fallback);
  }
}
