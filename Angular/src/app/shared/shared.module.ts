import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedRoutingModule } from './shared-routing.module';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { HttpClientModule } from '@angular/common/http';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AfterLoginHeaderComponent } from './components/after-login-header/after-login-header.component';


@NgModule({
  declarations: [HeaderComponent, FooterComponent, DashboardComponent, AfterLoginHeaderComponent],
  imports: [
    CommonModule,
    SharedRoutingModule,
    HttpClientModule
  ],
  exports: [
    HeaderComponent,
    FooterComponent,
    HttpClientModule,
    DashboardComponent, 
    AfterLoginHeaderComponent
  ]
})
export class SharedModule { }
