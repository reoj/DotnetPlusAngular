export class Goal {
  id: number;
  name: string;
  description: string;
  dueDate: Date;
  isComplete: boolean;
  progressPercentage: number;
  constructor(
    id: number,
    name: string,
    description: string,
    deadline: Date,
    completed: boolean,
    progressPercentage: number
  ) {
    this.id = id;
    this.name = name;
    this.description = description;
    this.dueDate = deadline;
    this.isComplete = completed;
    this.progressPercentage = progressPercentage;
  }
}
