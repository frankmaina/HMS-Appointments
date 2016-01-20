from django.shortcuts import get_object_or_404, render
from django.http import HttpResponseRedirect, HttpResponse
from django.contrib.auth import authenticate, login, logout
from accounts.forms import signinform, signupform
from django.contrib.auth.models import User
from django.contrib.auth.decorators import login_required




def signin(request):
    if request.method == 'POST':  # check request method
        # collect POST data
        username = request.POST['Username']
        password = request.POST['Password']
        form = signinform(request.POST)
        if form.is_valid():  # if form has no errors
            try:
                user = User.objects.get(username=username)  # check if the user exists
                user = authenticate(username=username, password=password)
                if user is not None:
                    if user.is_active:
                        login(request, user)  # authentication past user is free to login
                        return HttpResponseRedirect('/')
                    else:
                        return HttpResponse("Account is not active")
                else:
                    message = 'The Username or Password was wrong. Please try again.'
                    return render(request, 'accounts/signin/index.html', {'message': message, 'form': form})

            except User.DoesNotExist:
                # the user was not found in the datatbase
                form = signinform()
                message = 'No account exists in such a name.'
                return render(request, 'accounts/signin/index.html', {'message': message, 'form': form})
        else:
            form = signinform()
            message = 'The form was not filled out correctly. Please fill in again.'
            return render(request, 'accounts/signin/index.html', {'message': message, 'form': form})
    else:
        # the form was not submitted hence render sign in page
        form = signinform()
        return render(request, 'accounts/signin/index.html', {'form': form})


def signup(request):
    if request.method == 'POST':  # if the form on the sign in page was actually submitted
        # it was submitted hence collect data
        username = request.POST['Username']
        password = request.POST['Password']
        email = request.POST['Email']
        first_name = request.POST['first_name']
        last_name = request.POST['second_name']
        form = signupform(request.POST)
        if form.is_valid():
            try:
                # check if the user exists
                u = User.objects.get(username__exact=username)
                message = 'The specified user already exists.'
                return render(request, 'accounts/signup/index.html', {'message': message, 'form': form})
            except User.DoesNotExist:
                # if not create new user
                user = User.objects.create_user(username, email, password)
                user.first_name = first_name
                user.last_name = last_name
                user.save()
                user = authenticate(username=username, password=password)
                login(request, user)
                return HttpResponseRedirect('/')
        else:
            form = signupform()
            message = 'The submitted form was invalid, please fill it again.'
            return render(request, 'accounts/signup/index.html', {'message': message, 'form': form})

    else:  # probably a normal get request so return the form
        form = signupform()
        return render(request, 'accounts/signup/index.html', {'form': form})


# you should not be able to signout if you havent signed in in the first place
@login_required(login_url='/accounts/signin/')
def signout_view(request):
    logout(request)
    return HttpResponseRedirect('/')
