<note date=06/24/2019>
In the video-tutorials, they use Application.LoadLevel, but this method
is depreciated.
I used SceneManager.LoadScene instead.

-> in Scene00, the "clipping-plains-far" variable under Camera
had to be set to 100 in order for canval-ui elements to be visible.
My guess is that this is because the z-position of the Canvas is set to 100.
</note>