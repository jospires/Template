import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxPaginationModule } from 'ngx-pagination';
import { FormsModule } from '@angular/forms';

import { TeamListComponent } from './team-list/team-list.component';
import { TeamCreateComponent } from './team-create/team-create.component';
import { TeamEditComponent } from './team-edit/team-edit.component';
import { SharedModule } from '../shared/shared.module';


const routes: Routes = [
  { path: '', component: TeamListComponent },
  { path: 'create', component: TeamCreateComponent },
  { path: 'edit/:id', component: TeamEditComponent },
];

@NgModule({
  declarations: [
    TeamListComponent,
    TeamCreateComponent,
    TeamEditComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(routes),
    NgbModule,
    NgxPaginationModule,
    SharedModule
  ]
})
export class TeamsModule { }
