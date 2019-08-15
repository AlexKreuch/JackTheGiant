<note date=06/24/2019>
In the video-tutorials, they use Application.LoadLevel, but this method
is depreciated.
I used SceneManager.LoadScene instead.

-> in Scene00, the "clipping-plains-far" variable under Camera
had to be set to 100 in order for canval-ui elements to be visible.
My guess is that this is because the z-position of the Canvas is set to 100.
</note>

<note date=07/29/2019>
   version at branch 177 (before ads-plugin was introduced)
   has been copied to "..\azaa_BACKUPS\aaa_prj_01_backups\aaaa_backup_00"
   (relative to the current location of this read-me file).
 

</note>