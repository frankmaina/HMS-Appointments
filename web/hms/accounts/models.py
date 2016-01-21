from django.db import models
from django.forms import ModelForm
from django.contrib.auth.models import User


class UserProfile(models.Model):
    user = models.OneToOneField(User)
    role = models.CharField(max_length=55, null=True)
