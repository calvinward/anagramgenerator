var gulp = require('gulp');
var clean = require('gulp-clean');

gulp.task('default', function () {
    console.log('Hello world.');
});


var bases = {
    app: 'app/',
    dist: 'dist/',
};

// Delete the dist directory
gulp.task('clean', function () {
    return gulp.src(bases.dist)
    .pipe(clean());
});


gulp.task('watch', function () {
    gulp.watch('app/**/*', ['announce']);
});

gulp.task('announce', function () {
    console.log('watching');
});


gulp.task('vendor', ['clean'], function () {
    gulp.src('bower_components/**/angular*js*').pipe(gulp.dest('dist/vendor/'));
    gulp.src('bower_components/jquery/dist/**/jquery.*').pipe(gulp.dest('dist/vendor/jquery/'));
    gulp.src('bower_components/bootstrap/dist/**/*.min.*').pipe(gulp.dest('dist/vendor/bootstrap/'));
    gulp.src('bower_components/bootstrap/dist/**/*.map').pipe(gulp.dest('dist/vendor/bootstrap/'));
    gulp.src('bower_components/bootstrap/dist/fonts/*').pipe(gulp.dest('dist/vendor/bootstrap/fonts'));
    gulp.src('bower_components/font-awesome/fonts/*').pipe(gulp.dest('dist/vendor/font-awesome/fonts'));
    gulp.src('bower_components/font-awesome/css/*.min.*').pipe(gulp.dest('dist/vendor/font-awesome/css'));
    gulp.src('bower_components/font-awesome/css/*.map').pipe(gulp.dest('dist/vendor/font-awesome/css'));
    gulp.src('bower_components/toastr/*.min.*').pipe(gulp.dest('dist/vendor/toastr'));
    gulp.src('bower_components/blockui/jquery.blockUI.js').pipe(gulp.dest('dist/vendor/blockui'));
});


