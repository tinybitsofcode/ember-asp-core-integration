import DS from 'ember-data';

export default DS.Model.extend({
  title: DS.attr('string'),
  contacts: DS.hasMany('contact')
});
