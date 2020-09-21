import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TaskRoutingModule } from './task-routing.module';
import { CreateOrEditTaskComponent } from './components/create-or-edit-task/create-or-edit-task.component';
import { TaskListComponent } from './components/task-list/task-list.component';
import { BsModalModule, BsModalService } from 'ng2-bs3-modal';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
@NgModule({
  declarations: [CreateOrEditTaskComponent, TaskListComponent],
  imports: [
    CommonModule,
    TaskRoutingModule,
    BsModalModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
  ], exports: [
    CreateOrEditTaskComponent, TaskListComponent, BsModalModule,
    NgbModule,
  ], providers: [
    BsModalService
  ],
  entryComponents:[
    CreateOrEditTaskComponent
  ]
})
export class TaskModule { }
