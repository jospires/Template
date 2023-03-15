import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Project } from '../project.model';
import { ProjectsService } from '../projects.service';
import { ConfirmationModalComponent } from '../../shared/confirmation-modal/confirmation-modal.component';

@Component({
  selector: 'app-project-list',
  templateUrl: './project-list.component.html',
  styleUrls: ['./project-list.component.css']
})
export class ProjectListComponent implements OnInit {

  @ViewChild(ConfirmationModalComponent) confirmationModal?: ConfirmationModalComponent;

  projects!: Project[];

  currentPage: number = 1;
  totalItems: number = 0;

  constructor(
    private projectsService: ProjectsService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.getProjects();
  }

  getProjects(): void {
    var skip = (this.currentPage - 1) * 5;
    this.projectsService.getProjects(skip, 5).subscribe(projects => {
      this.projects = projects[0];
      this.totalItems = projects[1];
    });
  }

  createProject(): void {

    this.router.navigate(['create'], { relativeTo: this.route });
  }

  updateProject(id: number) {
    this.router.navigate(['edit', id], { relativeTo: this.route });
  }

  deleteProject(id: number) {
    const message = 'Are you sure you want to delete this item?';
    this.confirmationModal?.show(message);
  }

  onDeleteConfirmed(confirmed: boolean, id: number) {
    if (confirmed) {
      this.projectsService.deleteProject(id).subscribe(projects => {
        this.getProjects();
      });
    }
  }

  onPageChange(pageNumber: number): void {
    this.currentPage = pageNumber;
    this.getProjects();
  }

}
