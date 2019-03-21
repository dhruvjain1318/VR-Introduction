### INFO 5340 / CS 5650
### Virtual and Augmented Reality 
# Assignment 3

Read: [Assignment Instructions](https://docs.google.com/document/d/1UmOILZSWxKzGknEvfYXPB562EG_wgiizo4Uk9ZI3aPU/edit "Detailed Assignment Instructions")

<hr>

### Student Name:

[Insert your full name]

### Student Email:

[Insert your Cornell email address]

<hr>

### Part 1
Insert your answers to the questions below

### Google Earth VR Questions

1. Where did you go and why?

The first location I went to was the Hoover Dam, because I wanted to see how the application would feel with large, wide-open spaces, and locations that have “dangerous” areas in real life, such as cliff edges, the deep drop, and the roads around the area. I also tried the Florence Cathedral because of its road density, to see how it would handle street view if that area, vs flying around above it.


2. Did you feel â€˜presentâ€™ in those locations? Why or why not?

I felt most present surprisingly while in the world view, flying around in space. This was because I was immersed in the viewpoints, being able to move around on my own, and teleport if I wanted to. There was some breakage because I don’t think I had the goggles on snug, so I saw a bit of the floor in the classroom, but overall it was great, and I did get a bit nervous at cliff edges.  There was a very wide field of view with high resolution and refresh rate, and the optics blended together from both eyes to make a very good experience. I think because of the nature of street view in google earth, the resolution was lowered once in street view, due to the stationary pictures that didn’t have much pixel density, but the field of view was still superb as well as the tracking and optics.


3. Did you feel motion sickness while exploring the world? If so, what do you think caused that feeling?

I did not feel any motion sickness while exploring the world surprisingly, however I did get a bit nervous on edges as mentioned. I believe this was because the optical presentation was so realistic in rendering depth information that my eyes were sending messages to my brain that I actually WAS on a cliff edge, and in danger of falling.


4. Do you consider the UI/UX in Google Earth VR to be intuitive? Why or why not?

I don’t think the UI/UX was that intuitive, other than teleportation and flying.  Those came naturally as it was very simple controls, point and clicking basically. Moving into street view was particularly difficult, needing to hold up the orb in one hand, then point at it and shoot in the other was cumbersome. Also figuring out the menu to pick new locations, and accidentally switching from earth below to earth in front was tricky for me. I believe some of this comes from the unfamiliarity with VR controls, with respect to the controllers I am used to for traditional game devices.


### Rec Room Questions

1. Did you feel connected to your avatar after customizing them? Why or why not?

I did feel connected to my avatar after customizing them! I think part of it was the clever use of rendering the motion controllers as hands made it feel like the avatar actually was me. I could display some emotions in the mirror through hand gestures and moving around. Also, by customizing them to my style it felt truly unique.

2. When socializing with others, did it feel as if you were connecting with them on the same level as if you were in the same physical space? Why or why not?

After socializing with others, it felt very similar to connecting with them on physical level. In my attempt, I played Paddleball with another person from the internet. I think I was hindered by the lack of talking between the two of us, which may have been from a lack of a mic on their end. However, from a physical perspective it was intriguing to see how much information could be translated between us. For instance, I was able to see my opponent shrug after a particularly non-competitive game where we always scored on the first initial hit. I also was able to communicate shared joy through dances and hand gestures between myself and my opponent.


3. Do you consider the UI/UX in Rec Room to be intuitive? Why or why not?

I found the UI/UX of Rec Room to be very intuitive, as it was able to use motion controls very well to simulate my actual movement. The simply act of turning my hand to look at my watch was very intuitive, as it is a motion I am familiar with, and picked up immediately. The same went for playing paddleball, being able to physically reach out, hold a button similarly to the motion of actually gripping the ball, and see the ball in my hand was great. This combined with the option to physically move around (as well as teleport if desired), made for very intuitive controls.

<hr>

### Part 2

### Solution (Screen Recording):

https://youtu.be/n97BdefpcKw

### Work Summary:

[Write a short summary of your approach and list challenges]

I first added atmosphere coloring with the skybox, fog, and floor color. As this was through the inspector/GUI, it was relatively simple, just needed to know the names of the created material to pull into the skybox, and change the color in the color wheel for fog and floor.

Adding the UI controls was also relatively simple through the SteamVR Input GUI. Finding an asset in Poly was fun, and positioning it in the scene was also relatively simple through the inspector.

The first challenge I face was displaying the attribution text for the model browser. I didn't quite understand how that info was acquired, so I kept looking in the inspector for some sort of component to grab for Name and Author. Later realized this info was already caught in other functions, and were attributes of ModelViewData, so I could simply call them, I didn't need to find out how to grab from the internet.

Adding components was relatively easy after I knew the AddComponent script, which was a lot of the assignment. Needed to simply poll the child compnents to check if they had a meshfilter component to decide whether to add other components.

The largest challenge came in finding the syntax and command for getting input from the Trackpad. SteamVR documentation is not the best, and it took me a couple hours to find the correct syntax in the guide provided, through the gif. Then it was simply understanding which function (GetAxis) to use under the ScaleItem action.

The last challenges were more about understanding the syntax for rotation and scaling, to Lerp towards the given position, but not in the positional sense. Once I figured out that Lerp actually worked for rotation and scale, it was fun to figure out where to put the code.

Lastly, adding color and rigidbodies was again adding components based on existing parameters (collision system, meshes, etc.)
<hr>
