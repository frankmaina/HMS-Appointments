from django.shortcuts import render
from django.http import HttpResponse
from django.contrib.auth.decorators import login_required


@login_required(login_url='/accounts/signin/')
def index(request):
    user = request.user
    return render(request, 'home/index.html',{'user':user})
