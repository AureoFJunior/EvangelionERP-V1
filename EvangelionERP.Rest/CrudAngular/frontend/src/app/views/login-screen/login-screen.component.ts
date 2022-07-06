import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/componentes/user/user.model';
import { UserService } from 'src/app/componentes/user/user.service';
import { StorageService } from 'src/app/services/storage.service';

@Component({
  selector: 'app-login-screen',
  templateUrl: './login-screen.component.html',
  styleUrls: ['./login-screen.component.css']
})
export class LoginScreenComponent implements OnInit {

  hide = true;

  user: User = {
    fullName: '',
    userName: '',
    password: '',
    mobile: '',
    email: '',
    userType: '',
    profilePicture: '',
    publicIdPicture: '',
    isLogged: 1,
  }

  constructor(private userService: UserService, private router: Router, private storageService: StorageService) { }

  ngOnInit(): void {
  }

  login(): void {
    if (this.user.userName !== '' && this.user.password !== '') {
    this.userService.login(this.user).subscribe(user => {
      this.userService.showMessage(`Login efetuado com sucesso! Bem-vindo, ${this.user.userName}   =)`, 'sucesso')
      this.storageService.setData('token',user.token)
      this.storageService.setData('refreshToken',user.refreshToken)
      this.router.navigate(['/home']);
    })

    this.user.isLogged = 1;
    this.userService.changeStatus(this.user)
  }
  else {
    this.userService.showMessage('Os campos precisam ser preenchidos. Verifique', 'erro')

    this.user.isLogged = 0;
    this.userService.changeStatus(this.user)

    this.router.navigate(['/'])
  }
  }

  signup(): void {
    this.router.navigate(['/signup'])
  }

}
