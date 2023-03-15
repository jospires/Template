import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Project } from '../project.model';
import { ProjectsService } from '../projects.service';
import { TeamsService } from '../../teams/teams.service';
import { Team } from '../../teams/team.model';

@Component({
  selector: 'app-project-create',
  templateUrl: './project-create.component.html',
  styleUrls: ['./project-create.component.css']
})

export class ProjectCreateComponent implements OnInit {

  teams!: Team[];

  newProject: Project = {
    id: 0,
    teamId: 0,
    name: '',
    description: '',
    startDate: new Date(),
    expectedEndDate: new Date(),
    endDate: new Date(),
    team: null
  };

  constructor(
    private router: Router,
    private projectsService: ProjectsService,
    private teamsService: TeamsService
  ) { }

  ngOnInit() {
    this.teamsService.getAllTeams().subscribe(teams => {
      this.teams = teams[0];
    });
  }

  createProject(): void {
    this.projectsService.createProject(this.newProject)
      .subscribe(() => this.goBack());
  }

  goBack(): void {
    this.router.navigate(['/projects']);
  }

}
