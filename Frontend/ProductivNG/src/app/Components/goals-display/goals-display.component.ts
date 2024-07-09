import { Component } from '@angular/core';
import { GoalsService } from 'src/app/Services/goals.service';
import { Goal } from 'src/app/Models/Goal';

@Component({
  selector: 'app-goals-display',
  templateUrl: './goals-display.component.html',
  styleUrls: ['./goals-display.component.css']
})
export class GoalsDisplayComponent {
  goals: Goal[] = [];

  constructor(private goalsService: GoalsService) {
    this.goals = goalsService.getGoals();
  }
}
