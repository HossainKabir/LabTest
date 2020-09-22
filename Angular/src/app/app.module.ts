import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthModule } from './auth/auth.module';
import { TaskModule } from './task/task.module';
import { SharedModule } from './shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { JwtModule } from '@auth0/angular-jwt';
import { AlertifyService } from './service/alert.service';
import { NgSelectConfig,NgSelectModule } from '@ng-select/ng-select';


export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    ReactiveFormsModule,
    BrowserModule,
    AppRoutingModule,
    AuthModule,
    TaskModule,
    SharedModule,
    FormsModule,
    NgSelectModule,
    JwtModule.forRoot({
      config: {
        tokenGetter:tokenGetter,
        allowedDomains: ['localhost:44318'],
        disallowedRoutes: ['localhost:44318/api/auth']
      },
    }),
  ],
  providers: [
    AlertifyService,
    NgSelectConfig
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }


