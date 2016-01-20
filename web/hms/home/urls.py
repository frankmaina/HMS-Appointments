
from django.conf.urls import include, url
from django.contrib import admin
import home.views


urlpatterns = [
  url(r'^$', home.views.index, name='home')
]
