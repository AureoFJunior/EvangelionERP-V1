import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/componentes/user/user.model';
import { UserService } from 'src/app/componentes/user/user.service';

@Component({
  selector: 'app-signup-screen',
  templateUrl: './signup-screen.component.html',
  styleUrls: ['./signup-screen.component.css']
})
export class SignupScreenComponent implements OnInit {
  hide = true;

  user: User = {
    fullName: '',
    userName: '',
    password: '',
    mobile: '',
    email: '',
    userType: 'P',
    profilePicture: '',
    publicIdPicture: '',
    isLogged: 0,
  }

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit(): void {
  }

  cancel(): void {
    this.router.navigate(['/'])
  }

  signup(): void {
    if (this.user.userName !== "") {
      this.userService.create(this.user).subscribe(() => {
        this.userService.showMessage('Cadastro efetuado com sucesso!', 'sucesso')
        
        this.router.navigate(['/']);
      })
  }
  //Não deixa cadastrar se estiver vazio o nome do funcionário.
  else 
  {
    this.userService.showMessage('O nome de usuário precisa ser preenchido. Verifique', 'erro')
    this.router.navigate(['/signup'])
  }
  }

}
