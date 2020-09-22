import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/service/auth.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {
  userList = [];

  constructor(private authService: AuthService) { }
  ngOnInit() {
    this.authService.getUser().subscribe(res => {
      this.userList = res;
      console.log(res);
    })
  }

}
