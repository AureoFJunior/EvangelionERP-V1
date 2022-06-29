import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { User } from 'src/app/componentes/user/user.model';
import { UserService } from 'src/app/componentes/user/user.service';
import { StorageService } from 'src/app/services/storage.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  hide = true;
  selectedFile!: File;

  user: User = {
    fullName: 'Sasaki Kojiro',
    userName: '',
    password: '',
    mobile: '(54) 99605-8917',
    email: 'affteste@gmail.com',
    userType: 'P',
    profilePicture: '',
    publicIdPicture: '1',
    isLogged: 0,
  }


  constructor(private userService: UserService, private router: Router, private http: HttpClient,
     private snackBar: MatSnackBar, private storageService: StorageService) { }

  ngOnInit(): void {
    this.userService.isLogged().subscribe(users => {
      this.user = users
    })
  }

  handleFileInput(input: any) {
    
    let headers = new HttpHeaders()
    const token = this.storageService.getData('token')

    headers.set('Content-Type', 'multipart/form-data')
    headers.set('Access-Control-Allow-Origin', '*')
    headers.set('Authorization', 'Bearer ' + token)
    headers.set('Accept', '*/*')
    
    this.selectedFile = input.files[0]
    const fd = new FormData();
    
    fd.append('file', this.selectedFile, this.selectedFile.name);
    this.http.post('https://localhost:44396/api/Login/add/photo', fd, { headers: headers })
      .subscribe(res => {
        this.showMessage('Imagem de perfil alterada com sucesso!', 'sucesso');
        this.router.navigate(['/profile'])
      });
    
  }
  showMessage(msg: string, action: string): void {
    this.snackBar.open(msg, 'X', {
      duration: 3000,
      horizontalPosition: "right",
      verticalPosition: "top",
      panelClass: action
    })
  }

}
