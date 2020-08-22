###########################################################
# QWOP with Farts PROTOTYPE
#
# Yeah
###########################################################

###########################################################
#                    Imported Libraries                   #
###########################################################

import simplegui

###########################################################
#                       Load Assets                       #
###########################################################

###########################################################
#                     Literal Constants                   #
###########################################################

###########################################################
#                     Global Variables                    #
###########################################################

g_game_running = True

g_e_timer_down = None
g_e_timer_up   = None
g_f_timer_down = None
g_f_timer_up   = None

g_e_instruct = 'Up'
g_f_instruct = 'Up'

g_e_state = 'Up'
g_f_state = 'Up'


g_e_health = 100
g_f_health = 100

###########################################################
#                     Defined Classes                     #
###########################################################

###########################################################
#                      Event Handlers                     #
###########################################################
    
    
def keydwn_hndlr( p_key ):
    """
    Handles key presses.
    """
    
    # Import globals
    global g_e_state, g_f_state
    
    # Perform key function
    if p_key == simplegui.KEY_MAP['E']:
        g_e_state = "Down"
    elif p_key == simplegui.KEY_MAP['F']:
        g_f_state = "Down"
                
    
def keyup_hndlr( p_key ):
    """
    Handles key releases.
    """
    
    # Import globals
    global g_e_state, g_f_state
    
    # Perform key function
    if p_key == simplegui.KEY_MAP['E']:
        g_e_state = "Up"
    elif p_key == simplegui.KEY_MAP['F']:
        g_f_state = "Up"

# Handler to draw on canvas
def draw_hndlr( p_canvas ):
    
    # Import globals
    global g_game_running, g_e_health, g_f_health, g_e_instruct, g_f_instruct, g_e_state, g_f_state
    
    if g_game_running:
        p_canvas.draw_text( 'E:',         [60,  50], 20, "White" )
        p_canvas.draw_text( 'F:',         [60, 150], 20, "White" )
        p_canvas.draw_text( g_e_state,    [100, 50], 20, "White" )
        p_canvas.draw_text( g_f_state,    [100,150], 20, "White" )
        p_canvas.draw_text( g_e_instruct, [150, 50], 20, "Red"   )
        p_canvas.draw_text( g_f_instruct, [150,150], 20, "Red"   )
    
        p_canvas.draw_polygon( [ [200, 30], [200, 50],
                                 [(200 + g_e_health), 50],
                                 [(200 + g_e_health), 30] ],
                               1, "White", "White" )
        p_canvas.draw_polygon( [ [200,130], [200,150],
                                 [(200 + g_f_health),150],
                                 [(200 + g_f_health),130] ],
                               1, "White", "White" )
    else:
        p_canvas.draw_text( 'YOU A DEAD', [20, 100], 40, "Red" )
    
def e_timer_down_hndlr():
    
    # Import globals
    global g_e_instruct, g_e_timer_up
    
    g_e_instruct = "Up"
    g_e_timer_down.stop()
    g_e_timer_up.start()
    
def e_timer_up_hndlr():
    
    # Import globals
    global g_e_instruct, g_e_timer_down
    
    g_e_instruct = "Down"
    g_e_timer_up.stop()
    g_e_timer_down.start()
    
def f_timer_down_hndlr():
    
    # Import globals
    global g_f_instruct, g_f_timer_up
    
    g_f_instruct = "Up"
    g_f_timer_down.stop()
    g_f_timer_up.start()
    
def f_timer_up_hndlr():
    
    # Import globals
    global g_f_instruct, g_f_timer_down
    
    g_f_instruct = "Down"
    g_f_timer_up.stop()
    g_f_timer_down.start()
    
def health_timer_hndlr():
    
    # Import globals
    global g_game_running, g_e_health, g_f_health, g_e_instruct, g_f_instruct, g_e_state, g_f_state
    
    if g_e_instruct != g_e_state:
        g_e_health -= 2
    else:
        g_e_health = (g_e_health+1) if g_e_health < 100 else 100
        
    if g_f_instruct != g_f_state:
        g_f_health -= 2
    else:
        g_f_health = (g_f_health+1) if g_f_health < 100 else 100
        
    if g_f_health < 0 or g_e_health < 0:
        g_game_running = False
    

###########################################################
#                     Helper Functions                    #
###########################################################

###########################################################
#                      Main Function                      #
###########################################################

# Create a frame and assign callbacks to event handlers
l_frame = simplegui.create_frame( "Home", 300, 200 )
l_frame.set_draw_handler( draw_hndlr )
l_frame.set_keydown_handler( keydwn_hndlr )
l_frame.set_keyup_handler( keyup_hndlr )

g_e_timer_down = simplegui.create_timer( 1000.0, e_timer_down_hndlr  )
g_e_timer_up   = simplegui.create_timer( 1000.0, e_timer_up_hndlr    )
g_f_timer_down = simplegui.create_timer( 2000.0, f_timer_down_hndlr )
g_f_timer_up   = simplegui.create_timer( 2000.0, f_timer_up_hndlr   )
l_timer_health = simplegui.create_timer( 90.0, health_timer_hndlr   )

g_e_timer_up.start()
g_f_timer_up.start()
l_timer_health.start()

# Start the frame animation
l_frame.start()

######################## End Program ######################
