'use strict';

$(function () {
  const select3 = $('.select3');

  

  // select2
  if (select3.length) {
    select3.each(function () {
      var $this = $(this);
      $this.wrap('<div class="position-relative"></div>');
      $this.select3({
       // placeholder: 'يرجى الإختيار',
        dropdownParent: $this.parent()
      });
    });
  }
});
