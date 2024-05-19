document.addEventListener('DOMContentLoaded', function() {
  var inputs = document.querySelectorAll('.user-info input');
  var subnavbar = document.querySelector('.register');

  inputs.forEach(function(input) {
      input.addEventListener('focus', function() {
          subnavbar.classList.add('focused');
      });
      input.addEventListener('blur', function() {
          subnavbar.classList.remove('focused');
      });
  });
});