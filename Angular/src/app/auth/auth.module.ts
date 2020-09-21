import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthRoutingModule } from './auth-routing.module';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { JwtModule } from '@auth0/angular-jwt';
import { AlertifyService } from '../service/alert.service';
import { UserListComponent } from './components/user-list/user-list.component';

export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [LoginComponent, RegisterComponent, UserListComponent],
  imports: [
    CommonModule,
    AuthRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    JwtModule.forRoot({
      config: {
        tokenGetter,
        allowedDomains: ['localhost:44318'],
        disallowedRoutes: ['localhost:44318/api/auth']
      },
    }),
  ],
  exports: [
    LoginComponent, RegisterComponent,UserListComponent,FormsModule
  ],
  providers: [AlertifyService]
})
export class AuthModule { }
