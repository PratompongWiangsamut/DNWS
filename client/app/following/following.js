'use strict';

angular.module('followingList', ['ngRoute'])
  .component('followingList', {
    templateUrl: 'following/following.html',
    controller: ['$http', '$rootScope', function TweetListController($http, $rootScope) {
      var self = this;

      const requestOptions = {
          headers: { 'X-session': $rootScope.x_session }
      };

      $http.get('http://localhost:8080/twitterapi/following/', requestOptions).then(function (response) {
        self.followings = response.data;
        });

        self.Following = function Following(followingname) {
            const data = "followingname=" + encodeURIComponent(followingname);
            $http.post('http://localhost:8080/twitterapi/following/', data, requestOptions).then(function (response) {
                console.log(response);
                alert("Start Follow " + encodeURIComponent(followingname))
            });
        }

        self.Unfollow = function Unfollow(followingname) {
            const data = "followingname=" + encodeURIComponent(followingname);
            $http.delete('http://localhost:8080/twitterapi/following/?' + data, requestOptions).then(function (response) {
                console.log(response);
                alert("Unfollow " + encodeURIComponent(followingname))
            });
        }
    }]
});