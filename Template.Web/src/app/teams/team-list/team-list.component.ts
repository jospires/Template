import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Team } from '../team.model';
import { TeamsService } from '../teams.service';
import { ConfirmationModalComponent } from '../../shared/confirmation-modal/confirmation-modal.component';

@Component({
  selector: 'app-team-list',
  templateUrl: './team-list.component.html',
  styleUrls: ['./team-list.component.css']
})
export class TeamListComponent implements OnInit {

  @ViewChild(ConfirmationModalComponent) confirmationModal?: ConfirmationModalComponent;

  teams!: Team[];

  currentPage: number = 1;
  totalItems: number = 0;

  constructor(
    private teamsService: TeamsService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.getTeams();
  }

  getTeams(): void {
    var skip = (this.currentPage - 1) * 5;
    this.teamsService.getTeams(skip, 5).subscribe(teams => {
      this.teams = teams[0];
      this.totalItems = teams[1];
    });
  }

  createTeam(): void {

    this.router.navigate(['create'], { relativeTo: this.route });
  }

  updateTeam(id: number) {
    this.router.navigate(['edit', id], { relativeTo: this.route });
  }

  deleteTeam(id: number) {
    const message = 'Are you sure you want to delete this item?';
    this.confirmationModal?.show(message);
  }

  onDeleteConfirmed(confirmed: boolean, id: number) {
    if (confirmed) {
      this.teamsService.deleteTeam(id).subscribe(teams => {
        this.getTeams();
      });
    }
  }

  onPageChange(pageNumber: number): void {
    this.currentPage = pageNumber;
    this.getTeams();
  }

}
