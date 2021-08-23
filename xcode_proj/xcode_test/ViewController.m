//
//  ViewController.m
//  xcode_test
//
//  Created by Ilnur Shafigullin on 23.08.2021.
//

#import "ViewController.h"
#import "curl.h"

@interface ViewController ()

@end

@implementation ViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view.
    
    CURL *curl = curl_easy_init();
    if(!curl)
        return;
    
    curl_easy_setopt(curl, CURLOPT_URL, "https://gost.cryptopro.ru");
    curl_easy_setopt(curl, CURLOPT_VERBOSE, 1);
    curl_easy_setopt(curl, CURLOPT_SSL_VERIFYHOST, 0);
    curl_easy_setopt(curl, CURLOPT_SSL_VERIFYPEER, 0);
    
    CURLcode res = curl_easy_perform(curl);
    curl_easy_cleanup(curl);
    if(res != CURLE_OK)
        return;
}


@end
