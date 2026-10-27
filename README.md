<details>
<summary>Disclaimer</summary>
This repo primarily exists for personal use, and so projects I'm working on that have multiple programmers can share these utility/helper classes. Again, please note that these tools are built for my own projects; <b><ins>this means that they could change in functionality at any time</ins></b>. If you plan on using them long term, I strongly suggest sticking to one version/installing a packing and sticking to it, or paying very close attention to each update/commit. Feel free to use these in your own projects or base your own code off of mine, no credit needed; just don't claim it as your own.
</details>

# Dev Menu
Quickly add development functions to the dev menu with just a few function calls!
This system uses the builder pattern to allow for modular creation of menu entries.
```cs
DevMenuUI.Instance.AddEntry("Debug Logs", "Red").WithButton(() => Debug.Log("<color=#F00>I am red!</color>")).Build();
DevMenuUI.Instance.AddEntry("Debug Logs", "Green").WithButton(() => Debug.Log("<color=#0F0>I am green!</color>")).Build();
DevMenuUI.Instance.AddEntry("Debug Logs", "Blue").WithButton(() => Debug.Log("<color=#00F>I am blue!</color>")).Build();

// Press button to invoke event
DevMenuUI.Instance.AddEntry("Parameters", "Toggle and Button").WithButton<bool>(OnToggle).WithToggle().BuildButton().Build();
DevMenuUI.Instance.AddEntry("Parameters", "Slider and Button").WithButton<float>(OnSlider).WithSlider(0, 1).BuildButton().Build();

// Event is invoked upon value change
DevMenuUI.Instance.AddEntry("Parameters", "Toggle").WithToggle().WithEvent<bool>(OnToggle).Build();
DevMenuUI.Instance.AddEntry("Parameters", "Slider").WithSlider(0, 1).WithEvent<float>(OnSlider).Build();

void OnToggle(bool value) => Debug.Log(value);
void OnSlider(float value) => Debug.Log(value);
```
# IMPORTANT
I don't know if this will import to pre-Unity 6 versions, I've been messing around with the dependencies trying to get them right