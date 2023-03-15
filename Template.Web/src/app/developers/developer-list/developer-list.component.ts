import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Developer } from '../developer.model';
import { DevelopersService } from '../developers.service';
import { ConfirmationModalComponent } from '../../shared/confirmation-modal/confirmation-modal.component';

@Component({
  selector: 'app-developer-list',
  templateUrl: './developer-list.component.html',
  styleUrls: ['./developer-list.component.css']
})
export class DeveloperListComponent implements OnInit {

  @ViewChild(ConfirmationModalComponent) confirmationModal?: ConfirmationModalComponent;

  developers!: Developer[];

  currentPage: number = 1;
  totalItems: number = 0;

  constructor(
    private developersService: DevelopersService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.getDevelopers();
  }

  getDevelopers(): void {
    var skip = (this.currentPage - 1) * 5;
    this.developersService.getDevelopers(skip, 5).subscribe(developers => {
      this.developers = developers[0];
      this.totalItems = developers[1];
    });
  }

  createDeveloper(): void {

    this.router.navigate(['create'], { relativeTo: this.route });
  }

  updateDeveloper(id: number) {
    this.router.navigate(['edit', id], { relativeTo: this.route });
  }

  deleteDeveloper(id: number) {
    const message = 'Are you sure you want to delete this item?';
    this.confirmationModal?.show(message);
  }

  onDeleteConfirmed(confirmed: boolean, id: number) {
    if (confirmed) {
      this.developersService.deleteDeveloper(id).subscribe(developers => {
        this.getDevelopers();
      });
    }
  }

  onPageChange(pageNumber: number): void {
    this.currentPage = pageNumber;
    this.getDevelopers();
  }

}
