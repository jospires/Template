import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Developer } from '../developer.model';
import { DevelopersService } from '../developers.service';
import { TeamsService } from '../../teams/teams.service';
import { Team } from '../../teams/team.model';

@Component({
  selector: 'app-developer-edit',
  templateUrl: './developer-edit.component.html',
  styleUrls: ['./developer-edit.component.css']
})

export class DeveloperEditComponent implements OnInit {

  teams!: Team[];

  developer: Developer = {
    id: 0,
    teamId: 0,
    firstName: '',
    lastName: '',
    email: '',
    dateOfBirth: new Date(),
    team: null
  };

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private developersService: DevelopersService,
    private teamsService: TeamsService
  ) { }

  ngOnInit() {
    this.teamsService.getAllTeams().subscribe(teams => {
      this.teams = teams[0];
    });

    let _id: number = this.route.snapshot.params['id'];

    this.developersService.getDeveloper(_id)
      .subscribe(developer => this.developer = developer);
  }

  saveDeveloper(): void {
    if (this.developer) {
      this.developersService.updateDeveloper(this.developer)
        .subscribe(() => this.goBack());
    }
  }

  goBack(): void {
    this.router.navigate(['/developers']);
  }
}
