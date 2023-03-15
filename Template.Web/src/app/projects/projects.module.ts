import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxPaginationModule } from 'ngx-pagination';
import { FormsModule } from '@angular/forms';

import { ProjectListComponent } from './project-list/project-list.component';
import { ProjectCreateComponent } from './project-create/project-create.component';
import { ProjectEditComponent } from './project-edit/project-edit.component';
import { SharedModule } from '../shared/shared.module';


const routes: Routes = [
  { path: '', component: ProjectListComponent },
  { path: 'create', component: ProjectCreateComponent },
  { path: 'edit/:id', component: ProjectEditComponent },
];

@NgModule({
  declarations: [
    ProjectListComponent,
    ProjectCreateComponent,
    ProjectEditComponent
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
export class ProjectsModule { }
