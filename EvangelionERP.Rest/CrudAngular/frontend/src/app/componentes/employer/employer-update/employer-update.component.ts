import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Employer } from '../employer.model';
import { EmployerService } from '../employer.service';

@Component({
  selector: 'app-employer-update',
  templateUrl: './employer-update.component.html',
  styleUrls: ['./employer-update.component.css']
})
export class EmployerUpdateComponent implements OnInit {

  constructor(private employerService: EmployerService, private router: Router, private route: ActivatedRoute) { }

  employer: Employer = {
    firstName: '',
    lastName: '',
    email: '',
    mobile: '',
    salary: 0
  }
  
  ngOnInit(): void {
    const cod = this.route.snapshot.paramMap.get('cod')
    this.employerService.readById(cod!).subscribe(employer => {
      this.employer = employer
    });
  }

  navigate(): void {
    this.router.navigate(['/employers']);
  }

  updateEmployer(): void {
    this.employerService.update(this.employer).subscribe(() => {
      this.employerService.showMessage(`Funcionário [${this.employer.firstName}] atualizado com sucesso! :)`, 'sucesso');
      this.navigate();
    });
  }

  cancel(): void {
    this.navigate();
    this.employerService.showMessage('Operação de edição cancelada :( ', 'erro');
  }
  
}
