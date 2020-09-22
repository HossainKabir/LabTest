import { Component, OnInit, ViewChild } from '@angular/core';
import { NgbModal, ModalDismissReasons, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbCalendar, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { NgSelectModule, NgOption } from '@ng-select/ng-select';
import { AuthService } from 'src/app/service/auth.service';
@Component({
  selector: 'app-create-or-edit-task',
  templateUrl: './create-or-edit-task.component.html',
  styleUrls: ['./create-or-edit-task.component.scss']
})
export class CreateOrEditTaskComponent implements OnInit {

  @ViewChild('modal1', { static: false }) modal: any;

  data = 0;
  yourModelDate = null;
  model: NgbDateStruct;
  today = this.calendar.getToday();

  closeResult = '';
  taskForm: FormGroup;

  userList = [];

  constructor(private modalService: NgbModal, private calendar: NgbCalendar, public activeModal: NgbActiveModal, private formBuilder: FormBuilder, private authService: AuthService) { }
  ngOnInit(): void {
    this.taskForm = this.formBuilder.group({
      taskName: ['', Validators.required],
      description: ['', Validators.required],
      startDate: ['', Validators.required],
      endDate: ['', Validators.required],
      user: ['', Validators.required],
    });
    this.authService.getUser().subscribe(res => {
      this.userList = res;
      console.log(res);
    })
  }

  open(content) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }
  closeModal(sendData) {
    this.activeModal.close(sendData);
  }

  get f() { return this.taskForm.controls; }
  onSubmit() {
console.log(this.taskForm.value);
    if (this.taskForm.invalid) {
      return;
    }

    // this.authService.register(this.taskForm.value).subscribe(
    //   next => {
    //     console.log(next);
    //     this.alertService.success('Registered successfully!');
    //     this.router.navigate(['/login']);
    //   },
    //   error => {
    //     console.log(error);
    //     console.log(error.error[0]);
    //     this.alertService.error(error.error[0]);

    //   },
    // );
  }
}
