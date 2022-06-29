import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-employer-crud',
  templateUrl: './employer-crud.component.html',
  styleUrls: ['./employer-crud.component.css']
})
export class EmployerCrudComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  //Faz a navegação para o cadastro de funcionários.
  navigateToEmployerCreate(): void {
    this.router.navigate(['/employers/create'])
  }

}
