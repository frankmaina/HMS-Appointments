
from django.conf.urls import include, url
from django.contrib import admin
import api.views


urlpatterns = [
  url(r'^validate/user/', api.views.validate, name='home')
]
