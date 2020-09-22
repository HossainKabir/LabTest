import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { JwtHelperService } from '@auth0/angular-jwt';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { FormGroup } from '@angular/forms';
import { TokenService } from './token.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = environment.apiUrl + 'user/';
  jwtHelper = new JwtHelperService();
  decodedToken: any;

  headers = new HttpHeaders({
    'Content-Type': 'application/json',
    'responseType': 'json',
    'Access-Control-Allow-Origin': '*'
  });
  constructor(private http: HttpClient,private token:TokenService) { }

  login(model: any) {
    return this.http.post(this.baseUrl + 'login', model, { headers: this.headers }).pipe(
      map((response: any) => {
        const user = response;
        if (user) {
          localStorage.setItem('token', user.token);
          this.decodedToken = this.jwtHelper.decodeToken(user.token);
        }
      })
    );
  }

  register(form: FormGroup) {
    return this.http.post(this.baseUrl + 'register', form, { headers: this.headers });
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }

  getUser():Observable<any> {
    debugger;
    return this.http.get<any[]>(this.baseUrl + 'getUser', { headers: this.token.headerToken() });
}


}
