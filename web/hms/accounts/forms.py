from django import forms


class signinform(forms.Form):
    Username = forms.CharField(widget=forms.TextInput(attrs={'class': 'form-control'}))
    Password = forms.CharField(widget=forms.TextInput(attrs={'class': 'form-control'}))


class signupform(forms.Form):
    CHOICES = (('Company', 'Company'), ('Individual', 'Individual'),)
    Username = forms.CharField(widget=forms.TextInput(attrs={'class': 'form-control'}))
    Password = forms.CharField(widget=forms.TextInput(attrs={'class': 'form-control'}))
    Email = forms.EmailField(widget=forms.TextInput(attrs={'class': 'form-control'}))
    first_name = forms.CharField(widget=forms.TextInput(attrs={'class': 'form-control'}))
    second_name = forms.CharField(widget=forms.TextInput(attrs={'class': 'form-control'}))
