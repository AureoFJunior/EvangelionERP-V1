import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from '../user.model';
import { UserService } from '../user.service';

@Component({
  selector: 'app-user-read',
  templateUrl: './user-read.component.html',
  styleUrls: ['./user-read.component.css']
})
export class UserReadComponent implements OnInit {

  users: User[] = [];
  displayedColumns: String[] = ['cod', 'fullName', 'userName', 'password', 'mobile', 'email', 'userType', 'action']
  
  constructor(private userService: UserService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    const cod = this.route.snapshot.paramMap.get('cod')

    this.userService.read().subscribe(users => {
    this.users = users.userData
    })
  }

}
