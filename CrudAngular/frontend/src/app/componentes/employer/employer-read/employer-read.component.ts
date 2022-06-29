import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { Employer } from '../employer.model';
import { EmployerService } from '../employer.service';

@Component({
  selector: 'app-employer-read',
  templateUrl: './employer-read.component.html',
  styleUrls: ['./employer-read.component.css']
})
export class EmployerReadComponent implements OnInit {

  employers: Employer[] = [];
  displayedColumns: String[] = ['cod', 'firstName', 'lastName', 'salary', 'email', 'mobile', 'action']
  dataSource = new MatTableDataSource<Employer>()
  @ViewChild(MatPaginator)
  paginator!: MatPaginator;
  
  constructor(private employerService: EmployerService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    const cod = this.route.snapshot.paramMap.get('cod')
    if (cod !== null) {
      if (cod !== "")
      this.deleteEmployer(cod!)
    }

    this.employerService.read().subscribe(employers => {
    this.dataSource = employers.employerDetails
    this.dataSource.paginator = this.paginator;
    })
  }

  deleteEmployer(cod: string): void {
    this.employerService.delete(cod).subscribe(employer => {
      this.employerService.showMessage(`Funcionário [${cod}] excluído com sucesso.`, 'sucesso')
    });
    this.router.navigate(['/employers'])
  }


}
