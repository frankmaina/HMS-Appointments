from django.shortcuts import render
from django.shortcuts import get_object_or_404, render
from django.http import HttpResponseRedirect, HttpResponse
from django.contrib.auth import authenticate, login, logout
from accounts.forms import signinform, signupform
from django.contrib.auth.models import User
from django.contrib.auth.decorators import login_required
from django.http import JsonResponse
from accounts.models import UserProfile
# i really have to make this more secure in the near future


def validate(request):
    if request.GET['username'] and request.GET['password']:
        # valid request

        try:
            user = authenticate(username=request.GET[
                                'username'], password=request.GET['password'])
            profile = UserProfile.objects.get(user=user)
            return JsonResponse({'result': 'OK', 'role': profile.role, 'first_name': user.first_name, 'last_name': user.last_name, 'email': user.email})
        except (User.DoesNotExist, UserProfile.DoesNotExist):
            return JsonResponse({'result': 'FAILED', 'reason': 'No matching query'})
    else:
        return HttpResponse("Invalid")
