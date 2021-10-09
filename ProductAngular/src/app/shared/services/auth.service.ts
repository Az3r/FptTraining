import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { throwError, of, Subject, Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IAuthToken } from 'src/app/shared/models/auth';
import { IUser } from '../models/user';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  readonly AUTH_URL = `${environment.apiUrl}/auth`
  readonly SECRET = "some string that is really secret";
  readonly AUDIENCE = "http://localhost:5000";
  readonly ISSUER = "http://localhost:4200";
  private jwt = new JwtHelperService();


  observer: Subject<IUser> = new Subject<IUser>()

  constructor(private http: HttpClient) { }

  onChanged() {
    return this.observer.asObservable();
  }

  async user() {
    const token = localStorage.getItem("access_token")

    if (!token) return undefined;
    return this.verify(token);
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

  private verify(token: string): Promise<IUser> {
    return new Promise((resolve, reject) => {
      try {
        const payload: { rol: string, name: string } = this.jwt.decodeToken(token)
        return resolve({ role: payload.rol, name: payload.name })
      } catch (error) {
        return reject(error)
      }
    })

  }

}
