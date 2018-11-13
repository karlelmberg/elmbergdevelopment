/// <binding />
var gulp = require('gulp');
var sass = require('gulp-sass');

gulp.task('sass-compile', function () {
  gulp.src(['./Static/scss/**/*.scss'])
    .pipe(sass())
    .pipe(gulp.dest('./Static/css/'));
});

gulp.task('watch-sass', function () {
  gulp.watch('./Static/scss/**/*.scss', ['sass-compile']);
});

gulp.task('test', function () {
    console.log('Gulp funkar bra! Kör gulp watch-sass');
});