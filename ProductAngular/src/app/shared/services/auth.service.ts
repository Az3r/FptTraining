import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { throwError, of, Subject, Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IAuthToken } from 'src/app/shared/models/auth';
import { IUser } from '../models/user';
import * as jwt from 'jsonwebtoken';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  readonly AUTH_URL = `${environment.apiUrl}/auth`
  readonly SECRET = "some string that is really secret";
  readonly AUDIENCE = "http://localhost:5000";
  readonly ISSUER = "http://localhost:4200";


  observer: Subject<IUser> = new Subject<IUser>()

  constructor(private http: HttpClient) { }

  onChanged() {
    return this.observer.asObservable();
  }

  user() {
    const accessToken = localStorage.getItem("access_token")
    const refreshToken = localStorage.getItem("refresh_token")

    // console.log(refreshToken === "undefined")
    if (refreshToken) return { accessToken, refreshToken }
    return undefined;
  }

  token(): Partial<IAuthToken> {
    const accessToken = localStorage.getItem("access_token")
    const refreshToken = localStorage.getItem("refresh_token")

    return { accessToken: accessToken || undefined, refreshToken: refreshToken || undefined }
  }

  async login(displayName: string, password: string): Promise<IAuthToken> {
    return this.http.post<IAuthToken>(`${this.AUTH_URL}/login`, { displayName, password })
      .pipe(
        catchError(error => this.onError<IAuthToken>("login", error)),
        tap(value => this.store(value))
      )
      .toPromise()
  }

  store(token: IAuthToken) {
    localStorage.setItem("access_token", token.accessToken!)
    localStorage.setItem("refresh_token", token.refreshToken!)

    this.verify(token.accessToken).then(payload => {
      this.observer.next(payload);
    }).catch(() => this.observer.next(undefined))
  }

  logout() {
    this.observer.next(undefined)
    localStorage.removeItem("access_token")
    localStorage.removeItem("refresh_token")
  }

  refresh() {
    const refreshToken = localStorage.getItem("refresh_token");
    if (!refreshToken) throw new Error("refresh_token_not_found");

    return this.http.post<IAuthToken>(`${this.AUTH_URL}/refresh`, { refreshToken })
      .pipe(
        catchError(error => this.onError<IAuthToken>("refresh", error)),
        tap(value => this.store(value))
      )
  }

  private onError<T>(operation: string, error: HttpErrorResponse, fallback?: T): Observable<T> {
    console.error(operation, error)
    if (fallback == undefined) return throwError(error)
    return of(fallback);
  }

  private async verify(token: string): Promise<IUser | undefined> {
    return new Promise((resolve, reject) => {
      jwt.verify(token, this.SECRET, { algorithms: ["HS512"] }, (err, payload) => {
        if (err) {
          console.error(err);
          return reject(err);
        }
        if (!payload) {
          console.log("Decoded JWT has empty payload");
          return resolve(undefined);
        }

        console.log(payload)
        return resolve({ name: payload.name, role: payload.rol })
      })
    })
  }

}
