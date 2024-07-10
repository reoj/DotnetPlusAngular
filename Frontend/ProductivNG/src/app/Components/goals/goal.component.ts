import { Component, Input } from '@angular/core';
import { Goal } from 'src/app/Models/Goal';

@Component({
  selector: 'app-goal',
  templateUrl: './goal.component.html',
  styleUrls: ['./goal.component.css']
})
export class GoalsComponent {
  @Input() goal: Goal = null!;
  
}
