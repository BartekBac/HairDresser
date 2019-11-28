import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { SelectItem } from 'primeng/primeng';
import { Opinion } from '../../models/Opinion';


@Component({
  selector: 'app-view-opinion-list',
  templateUrl: './view-opinion-list.component.html',
  styleUrls: ['./view-opinion-list.component.css']
})
export class ViewOpinionListComponent implements OnInit {

  @Input() opinions: Opinion[] = [];
  @Input() sendOpinionsMode = false;
  @Output() deletedOpinion = new EventEmitter<Opinion>();
  displayingOpinions: Opinion[];
  sortKey: string;
  sortOptions: SelectItem[] = [
    {label: 'Newest first', value: '!date'},
    {label: 'Oldest first', value: 'date'},
    {label: 'Highest rate', value: '!rate'},
    {label: 'Lowest rate', value: 'rate'}
  ];
  filteredSearchValues: string[];
  searchValue = '';

  constructor() { }

  ngOnInit() {
    this.displayingOpinions = this.opinions;
    this.sortKey = this.sortOptions[0].value;
    this.refreshFilters(this.sortKey, this.searchValue);
    this.sortDisplayingOpinions(this.sortKey);
  }

  onSortChange(event) {
    this.sortDisplayingOpinions(event);
  }

  private sortDisplayingOpinions(sortOption: string) {
    let order = 1;
    let value = sortOption;
    let sortedOpinions = [...this.displayingOpinions];
    if (value.indexOf('!') === 0) {
        order = -1;
        value = value.slice(1, value.length);
    }
    if (value === 'date') {
      sortedOpinions.sort((o1, o2) => {
        const res = (o1.date < o2.date) ? -1 : (o1.date > o2.date) ? 1 : 0;
        return res * order;
      });
    }
    if (value === 'rate') {
      sortedOpinions.sort((o1, o2) => {
        const res = (o1.rate < o2.rate) ? -1 : (o1.rate > o2.rate) ? 1 : 0;
        return res * order;
      });
    }
    this.displayingOpinions = sortedOpinions;
  }

  private unique(value, index, self) {
    return self.indexOf(value) === index;
  }

  filterSearchValues(event) {
    const query = event.query;
    if (query.length > 0) {
      this.filteredSearchValues = this.opinions.map(o => o.workerFirstName + ' ' + o.workerLastName)
                                               .filter(s => s.toLowerCase().startsWith(query.toLowerCase()));
    } else {
      this.filteredSearchValues = this.opinions.map(o => o.workerFirstName + ' ' + o.workerLastName);
    }
    this.filteredSearchValues = this.filteredSearchValues.filter(this.unique);
  }

  filter(query: string) {
    if (query.length > 0) {
      this.displayingOpinions = this.opinions.filter(o => {
        const workerName = o.workerFirstName + ' ' + o.workerLastName;
        return workerName.toLowerCase().includes(query.toLowerCase());
      });
    } else {
      this.displayingOpinions = this.opinions;
    }
  }

  refreshFilters(sortOption: string, query: string) {
    this.filter(query);
    this.sortDisplayingOpinions(sortOption);
  }

  onDeleteOpinion(opinion: Opinion) {
    this.deletedOpinion.emit(opinion);
  }

}
