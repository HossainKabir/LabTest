import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-after-login-header',
  templateUrl: './after-login-header.component.html',
  styleUrls: ['./after-login-header.component.scss']
})
export class AfterLoginHeaderComponent implements OnInit {

  constructor(private route: ActivatedRoute,
    private router: Router,) { }

  ngOnInit() {
  }
  singOut() {
    localStorage.setItem('token', "");
    this.router.navigate(['/login'])
      .then(() => {
        window.location.reload();
      });
  }
}
